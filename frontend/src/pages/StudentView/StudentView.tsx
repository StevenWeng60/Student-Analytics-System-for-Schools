import { useParams } from 'react-router-dom';
import { useEffect, useState } from 'react';
import Container from '@mui/material/Container';
import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';
import { useNavigate } from 'react-router-dom';
import StudentChart from './components/StudentChart';
import StudentDetails from './components/StudentDetails';
import StudentRecentAssignments from './components/StudentRecentAssignments';

export default function StudentView() {
    const { id } = useParams();
    const navigate = useNavigate();
    const [student, setStudent] = useState<any>(null);
    useEffect(() => {
    // Fetch student data based on ID
    // This is mock data - replace with actual API call
    const fetchStudent = async () => {
      // const response = await fetch(`/api/students/${id}`);
      // const data = await response.json();
      
      // Mock data for now
      const mockStudent = {
        id: id,
        name: 'John Doe',
        age: 20,
        email: 'john@example.com',
        major: 'Computer Science',
        gpa: 3.8,
        status: 'Active'
      };
      setStudent(mockStudent);
    };

    fetchStudent();
  }, [id]);

  if (!student) {
    return <div>Loading...</div>;
  }

  return (
    <Container>
      <Button onClick={() => navigate('/period-view')}>
        ← Back to Students
      </Button>
      
      <Typography variant="h4" sx={{ mt: 2 }}>
        Student Details
      </Typography>

      <div style={{ display: 'grid', gridTemplateColumns: '2fr 5fr', gridTemplateRows: '1fr 1fr', gap: '20px', marginTop: '20px', height: '900px' }}>
        <StudentDetails student={student} />
        <StudentChart/>
        <StudentRecentAssignments />
      </div>
    </Container>
  );
}