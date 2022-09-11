import React, { useState, useRef, useEffect, useMemo, useCallback } from 'react';
import { render } from 'react-dom';
import { AgGridReact } from 'ag-grid-react'; // the AG Grid React Component
import 'ag-grid-community/dist/styles/ag-grid.css';
import 'ag-grid-community/dist/styles/ag-theme-alpine.css';

const CustomerOrdersTab = () => {
    const gridStyle = useMemo(() => ({ height: '40vh', width: '100vw' }), []);

    const [columnDefs, setColumnDefs] = useState([
        { field: 'contactName' },
        { field: 'contactTitle' },
        { field: 'companyName' },
        { field: 'address' },
        { field: 'city' },
        { field: 'region' },
        { field: 'postalCode' },
        { field: 'country' },
        { field: 'phone' },
        { field: 'fax' },
    ]);

    const [orderDetailsCol, SetOrderDetailsCol] = useState([
        { field: 'orderDate' },
        { field: 'requiredDate' },
        { field: 'shippedDate' },
        { field: 'freight' },
        { field: 'shipName' },
        { field: 'shipAddress' },
        { field: 'shipCity' },
        { field: 'shipRegion' },
        { field: 'shipPostalCode' },
        { field: 'shipCountry' },        

    ]);

    const [rowData, SetRowData] = useState([]);

    const onGridReady = useCallback((params) => {

        fetch('/api/customer/customerorderscount')
            .then((resp) => resp.json())
            .then((data) => {
                let count = data;

                let page = 1;
                const dataSource = {
                    getRows: (params) => {
                        fetch('/api/customer/customerorders?page=' + page)
                            .then((resp) => resp.json())
                            .then((data) => {
                                params.successCallback(data, count);
                                page++;
                            });
                    },
                };
                params.api.setDatasource(dataSource);

            });
    }, []);

    const onSelectionChanged = useCallback((params) => {
        const selectedRow = params.api.getSelectedRows()[0];
        SetRowData([]);
        let newRows = [];
        for (const x of selectedRow.orders) {
            newRows.push(x)
        }
        SetRowData(newRows);
    }, []);


    return (
        <div>
            <h1>Customers</h1>
            <div className="ag-theme-alpine" style={gridStyle}>
                <AgGridReact
                    columnDefs={columnDefs} // Column Defs for Columns   
                    onGridReady={onGridReady}
                    domLayout={'normal'}
                    rowModelType={'infinite'}
                    cacheBlockSize={10}
                    maxConcurrentDatasourceRequests={1}
                    rowSelection={'single'}
                    onSelectionChanged={onSelectionChanged}
                />
            </div>

            <h1>Customer Orders</h1>
            <div className="ag-theme-alpine" style={gridStyle}>
                <AgGridReact
                    columnDefs={orderDetailsCol}
                    rowData={rowData}
                    domLayout={'normal'}

                />
            </div>
        </div>
    );
};

export default CustomerOrdersTab;