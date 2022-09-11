import React, { useState, useRef, useEffect, useMemo, useCallback } from 'react';
import { render } from 'react-dom';
import { AgGridReact } from 'ag-grid-react'; // the AG Grid React Component
import 'ag-grid-community/dist/styles/ag-grid.css';
import 'ag-grid-community/dist/styles/ag-theme-alpine.css';

const OrderTab = () => {
    const gridStyle = useMemo(() => ({ height: '40vh', width: '100vw' }), []);    

    const [columnDefs, setColumnDefs] = useState([            
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
        { field: 'employee.firstName' },
        { field: 'employee.lastName' },
    ]);

    const [orderDetailsCol, SetOrderDetailsCol] = useState([
        { field: 'product.productName' },
        { field: 'product.quantityPerUnit' },
        { field: 'product.unitPrice' },
        { field: 'product.unitsInStock' },
        { field: 'product.unitsOnOrder' },
        { field: 'product.reorderLevel' },
        { field: 'product.discontinued' },
        { field: 'product.category.categoryName' },
        { field: 'product.category.description' },
        { field: 'unitPrice' },
        { field: 'quantity' },
        { field: 'discount' },

    ]);

    const [rowData, SetRowData] = useState([]);

    const onGridReady = useCallback((params) => {

        fetch('/api/order/count')
            .then((resp) => resp.json())
            .then((data) => {
                let count = data;

                let page = 1;
                const dataSource = {
                    getRows: (params) => {
                        fetch('/api/order/orders?page=' + page)
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
        for(const x of selectedRow.orderDetails)
        {
            newRows.push(x)
        }        
        SetRowData(newRows);        
    }, []);


    return (
        <div>
            <h1>Orders</h1>
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

            <h1>Order Details</h1>
            <div className="ag-theme-alpine" style={gridStyle}>
                <AgGridReact
                    columnDefs={orderDetailsCol}
                    rowData={rowData }                    
                    domLayout={'normal'}                                       
                    
                />
            </div>
        </div>
    );
};

export default OrderTab;