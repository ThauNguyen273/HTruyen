import './App.css';
import { BrowserRouter, Routes, Route, Outlet  } from 'react-router-dom';
import Rules from './Components/Footer/Rules';
import Regulations from './Components/Footer/Regulations';
import Login from './Components/Accounts/Login';
import Signup from './Components/Accounts/Signup';
import Navbar from './Components/Header/Navbar';
import Home from './Pages/Home/Home';
import Category from './Pages/Categories/Category';
import Footer from './Components/Footer/Footer';
import CategoryDetail from './Pages/Categories/CategoryDetail';
import NovelCreate from './Pages/Admin/Novels/NovelCreate';
import ContactForm from './Components/Footer/ContactForm';

function App() {
  return(
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Layout/>}>
          <Route index element={<Home/>}/>
          <Route path="/rules" element={<Rules/>}/>
          <Route path="/regulations" element={<Regulations/>}/>
          <Route path='/contact' element={<ContactForm/>} />
          <Route path="/login" element={<Login/>}/>
          <Route path="/signup" element={<Signup/>}/>
          <Route path="/novel" element={<NovelCreate/>}/>
          <Route path="/category" element={<Category/>}/>
          <Route path="/:categoryMetalTile/:categoryId" element={<CategoryDetail/>}/>
        </Route>
      </Routes>
      </BrowserRouter>
  )
}

function Layout() {
  return (
    <div>
      <Navbar/>
      <Outlet/>
      <Footer/>
    </div>
  )
}

export default App;