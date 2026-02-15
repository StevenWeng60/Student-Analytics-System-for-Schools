import Box from '@mui/material/Box';
import Paper from '@mui/material/Paper';
import Divider from '@mui/material/Divider';
import Typography from '@mui/material/Typography';
import Avatar from '@mui/material/Avatar';
import Chip from '@mui/material/Chip';
import SchoolBee from '../../../assets/schoolbee.webp';
import BadgeIcon from '@mui/icons-material/Badge'; // Student ID
import SchoolIcon from '@mui/icons-material/School'; // Grade Level
import GradeIcon from '@mui/icons-material/Grade'; // Cumulative Grade
import EmojiEventsIcon from '@mui/icons-material/EmojiEvents'; // Class Rank

interface StudentDetailsProps {
  student: {
    id: number;
    name: string;
    age: number;
    email: string;
    major: string;
    gpa: number;
    status: 'Active' | 'Inactive' | 'Graduated';
  };
}

export default function StudentDetails({ student }: StudentDetailsProps) {
    const getStatusColor = (status: string) => {
    switch (status) {
      case 'Active':
        return 'success';
      case 'Inactive':
        return 'error';
      case 'Graduated':
        return 'info';
      default:
        return 'default';
    }
  };

  return (
    <Paper elevation={3} sx={{ gridColumn: '1',
          gridRow: 'span 2', p: 3, height: '100%', boxSizing: 'border-box' }}>
      {/* Header with Photo */}
      <Box sx={{ display: 'flex', alignItems: 'center', mb: 3 }}>
        <Avatar
          src={SchoolBee}
          alt={student.name}
          sx={{
            width: 100,
            height: 100,
            mr: 3,
            fontSize: '2.5rem',
            bgcolor: 'primary.main',
          }}
        >
        </Avatar>

        <Box sx={{ flexGrow: 1 }}>
          <Typography variant="h4" gutterBottom>
            {student.name}
          </Typography>
          <Chip
            label={student.status}
            color={getStatusColor(student.status)}
            size="small"
          />
        </Box>
      </Box>

      <Divider sx={{ mb: 2 }} />

      {/* Student Information */}
      <Box sx={{ display: 'flex', flexDirection: 'column', gap: 2 }}>
        {/* Email */}
        <Box sx={{ display: 'flex', alignItems: 'center', gap: 1 }}>
          <BadgeIcon color="action" />
          <Box>
            <Typography variant="caption" color="text.secondary">
              Student ID
            </Typography>
            <Typography variant="body1">{student.email}</Typography>
          </Box>
        </Box>

        {/* Grade Level */}
        <Box sx={{ display: 'flex', alignItems: 'center', gap: 1 }}>
          <SchoolIcon color="action" />
          <Box>
            <Typography variant="caption" color="text.secondary">
              Grade Level
            </Typography>
            <Typography variant="body1">6th</Typography>
          </Box>
        </Box>

        {/* Major */}
        <Box sx={{ display: 'flex', alignItems: 'center', gap: 1 }}>
          <GradeIcon color="action" />
          <Box>
            <Typography variant="caption" color="text.secondary">
              Cumulative Grade
            </Typography>
            <Typography variant="body1">92</Typography>
          </Box>
        </Box>

        {/* Year */}
        <Box sx={{ display: 'flex', alignItems: 'center', gap: 1 }}>
          <EmojiEventsIcon color="action" />
          <Box>
            <Typography variant="caption" color="text.secondary">
              Class Rank
            </Typography>
            <Typography variant="body1">20/26</Typography>
          </Box>
        </Box>

        <Divider sx={{ my: 1 }} />

        {/* Academic Stats */}
        <Box
          sx={{
            display: 'grid',
            gridTemplateColumns: 'repeat(2, 1fr)',
            gap: 2,
            mt: 1,
          }}
        >
        </Box>
      </Box>
    </Paper>
  );
}