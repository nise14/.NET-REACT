import { Outlet } from 'react-router';
import './App.css';
import NavBar from './components/navbar/NavBar';
import "react-toastify/dist/ReactToastify.css";
import { ToastContainer } from 'react-toastify';
import { UserProvider } from './context/useAuth';

function App() {
  return (
    <>
      <UserProvider>
        <NavBar />
        <Outlet />
        <ToastContainer />
      </UserProvider>
    </>);
}

export default App;
