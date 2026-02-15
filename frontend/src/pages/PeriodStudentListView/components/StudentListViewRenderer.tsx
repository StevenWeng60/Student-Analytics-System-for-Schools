import Container from '@mui/material/Container';
import { DataGrid, type GridColDef } from '@mui/x-data-grid';
import { useNavigate } from 'react-router-dom';

// Define your row type
interface Row {
  id: number;
  lastName: string;
  firstName: string;
  age: number;
}

export default function StudentListViewRenderer() {
  const navigate = useNavigate();

  const handleViewStudent = (id: number) => {
    navigate(`/student/${id}`);
  };

  const columns: GridColDef<Row>[] = [
    { field: 'id', headerName: 'ID', width: 70 },
    { field: 'firstName', headerName: 'First name', width: 130 },
    { field: 'lastName', headerName: 'Last name', width: 130 },
    { field: 'age', headerName: 'Age', type: 'number', width: 90 },
    {
        field: 'view',
        headerName: 'View',
        width: 100,
        renderCell: (params) => (
          <strong>
            <button
              style={{
                backgroundColor: '#1976d2',
                color: 'white',
                border: 'none',
                padding: '5px 10px',
                borderRadius: '4px',
                cursor: 'pointer',
              }}
              onClick={() => handleViewStudent(params?.row?.id)}
            >
              View
            </button>
          </strong>
        ),
    }
  ] as const;

  const rows: Row[] = [
    { id: 1, lastName: 'Snow', firstName: 'Jon', age: 35 },
    { id: 2, lastName: 'Lannister', firstName: 'Cersei', age: 42 },
    { id: 3, lastName: 'Stark', firstName: 'Arya', age: 16 },
  ];

  return (
    <Container className="Student-List-Renderer" sx={{ margin: 0 }}>
      <div style={{ height: 400, width: '100%' }}>
        <DataGrid rows={rows} columns={columns} />
      </div>
    </Container>
  );
}
