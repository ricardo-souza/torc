import { useEffect, useState } from "react";
import { DataGrid, GridColDef, GridToolbar } from '@mui/x-data-grid';
import api from "./services/api";

import './App.css'

type Book = {
  Id: number;
  Title: string;
  FirstName: string;
  LastName: string;
  TotalCopies: number;
  CopiesInUse: number;
  Type: string;
  Isbn: string;
  Category: string;
};

function App() {
  const [books, setBooks] = useState<Book[]>([]);

  const columns: GridColDef[] = [
    { field: 'title', headerName: 'Title', width: 150 },
    { field: 'firstName', headerName: 'FirstName', width: 150 },
    { field: 'lastName', headerName: 'LastName', width: 150 },
    { field: 'totalCopies', headerName: 'TotalCopies', width: 150 },
    { field: 'copiesInUse', headerName: 'CopiesInUse', width: 150 },
    { field: 'type', headerName: 'Type', width: 150 },
    { field: 'isbn', headerName: 'Isbn', width: 150 },
    { field: 'category', headerName: 'Category', width: 150 },
  ];


  useEffect(() => {
    api
      .get("/Book")
      .then((response) => setBooks(response.data))
      .catch((err) => {
        console.error("Error: " + err);
      });
  }, []);

  return (
    <div className="App">
      <h1>Royal Library</h1>
      <h2>Search Results:</h2>

      <div style={{ height: 300, width: '100%', backgroundColor: 'white' }}>
        <DataGrid 
          rows={books} 
          columns={columns}         
          disableColumnSelector
          disableDensitySelector
          components={{ Toolbar: GridToolbar }}
          componentsProps={{
            toolbar: {
              showQuickFilter: true,
              quickFilterProps: { debounceMs: 500 },
            },
          }} />
      </div>
    </div>
  )
}

export default App
