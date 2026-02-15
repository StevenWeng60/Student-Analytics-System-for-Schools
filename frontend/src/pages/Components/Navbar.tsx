import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';
import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';
import AccountCircle from '@mui/icons-material/AccountCircle';
import { Link } from 'react-router-dom';

export default function Navbar () {
    return (
        <AppBar position="static" sx={{ width: '100%'}}>
            <Toolbar>
                <IconButton
                size="large"
                edge="start"
                color="inherit"
                aria-label="menu"
                sx={{ mr: 2 }}
                >
                <MenuIcon />
                </IconButton>
                
                <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
                My App
                </Typography>
                
                <Button color="inherit" component={Link} to="/">
                Home
                </Button>
                <Button color="inherit" component={Link} to="/period-view">
                Period
                </Button>
                <Button color="inherit" component={Link} to="/products">
                Products
                </Button>
                
                <IconButton color="inherit">
                <AccountCircle />
                </IconButton>
            </Toolbar>
        </AppBar>
    );
};