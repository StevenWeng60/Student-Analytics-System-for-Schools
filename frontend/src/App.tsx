import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Home from './pages/Home/Home'
import NavBar from './pages/Components/Navbar'
import PeriodStudentListView from './pages/PeriodStudentListView/PeriodStudentListView'
import './App.css'
import StudentView from './pages/StudentView/StudentView';

function App() {
  return (
    <BrowserRouter>
    <NavBar/>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/period-view" element={<PeriodStudentListView/>} />
        <Route path="/student/:id" element={<StudentView/>} />
      </Routes>
    </BrowserRouter>
  )
}

export default App
