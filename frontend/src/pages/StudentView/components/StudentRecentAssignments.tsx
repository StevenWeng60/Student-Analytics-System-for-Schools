import Box from '@mui/material/Box';
import Paper from '@mui/material/Paper';
import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';
import Chip from '@mui/material/Chip';
import { DataGrid, type GridColDef } from '@mui/x-data-grid';

export default function StudentRecentAssignments() {
    const columns: GridColDef[] = [
    { field: 'date', headerName: 'Date', width: 120 },
    { field: 'assignment', headerName: 'Assignment', flex: 1 },
    { field: 'subject', headerName: 'Subject', width: 120 },
    {
      field: 'grade',
      headerName: 'Grade',
      width: 100,
      renderCell: (params) => {
        const grade = params.value as number;
        const color = grade >= 90 ? 'success' : grade >= 80 ? 'primary' : grade >= 70 ? 'warning' : 'error';
        return <Chip label={`${grade}%`} color={color} size="small" />;
      },
    },
    {
      field: 'status',
      headerName: 'Status',
      width: 100,
      renderCell: (params) => (
        <Chip 
          label={params.value} 
          color={params.value === 'Graded' ? 'success' : 'warning'}
          size="small"
          variant="outlined"
        />
      ),
    },
  ];

  const rows = [
    { id: 1, date: '2024-02-10', assignment: 'Math Quiz Ch. 5', subject: 'Math', grade: 92, status: 'Graded' },
    { id: 2, date: '2024-02-08', assignment: 'English Essay', subject: 'English', grade: 88, status: 'Graded' },
    { id: 3, date: '2024-02-05', assignment: 'Science Lab', subject: 'Science', grade: 95, status: 'Graded' },
    { id: 4, date: '2024-02-12', assignment: 'History Project', subject: 'History', grade: 0, status: 'Pending' },
  ];

    return (
        <Paper sx={{ p: 3, width: '800px'}}>
            <Box sx={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', mb: 2 }}>
            <Typography variant="h6">
                Recent Assignments
            </Typography>
            <Button variant="outlined" size="small">
                View All
            </Button>
            </Box>
            <DataGrid
            rows={rows}
            columns={columns}
            autoHeight
            hideFooter
            disableRowSelectionOnClick
            />
        </Paper>
    )
}