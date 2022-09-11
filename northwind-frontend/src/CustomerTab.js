import React, { useState, useRef, useEffect, useMemo, useCallback } from 'react';
import { render } from 'react-dom';
import { AgGridReact } from 'ag-grid-react'; // the AG Grid React Component
import 'ag-grid-community/dist/styles/ag-grid.css';
import 'ag-grid-community/dist/styles/ag-theme-alpine.css';

const CustomerTab = () => {
    const gridStyle = useMemo(() => ({ height: '100vh', width: '100vw' }), []);
    const [rowData, setRowData] = useState();
    
    const [columnDefs, setColumnDefs] = useState([
        { field: 'contactName'},
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

    const onGridReady = useCallback((params) => {

        fetch('/api/customer/count')
            .then((resp) => resp.json())
            .then((data) => {
                let count = data;
                let page = 1;
                const dataSource = {                    
                    getRows: (params) => {
                        fetch('/api/customer/customers?page=' + page)
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
  
            
    return (
        <div className="ag-theme-alpine" style={gridStyle}>
            <AgGridReact                    
                columnDefs={columnDefs} // Column Defs for Columns   
                onGridReady={onGridReady}
                domLayout={'normal'}
                rowModelType={'infinite'}
                cacheBlockSize={10}
                maxConcurrentDatasourceRequests={1}
            />
        </div>
    );
};

export default CustomerTab;