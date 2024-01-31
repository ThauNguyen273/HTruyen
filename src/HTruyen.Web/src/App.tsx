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
import ContactForm from './Components/Footer/ContactForm';
import Search from './Pages/Search/Search';
import ChapterCreate from './Pages/Author/Chapters/ChapterCreate';
import CreateNovel from './Pages/Author/Novels/CreateNovel';
import EditNovel from './Pages/Author/Novels/EditNovel';
import ManagerNovel from './Pages/Author/Dashboard/ManagerNovel';
import ListChapterNovel from './Pages/Author/Dashboard/ListChapterNovel';
import NovelDetail from './Components/Novels/NovelDetail';
import Nomination from './Pages/User/Nomination/Nomination';
import Comments from './Pages/User/Comments/Comments';
import CreateNomination from './Pages/User/Nomination/CreateNomination';
import CreateComments from './Pages/User/Comments/CreateComments';

function App() {
  return(
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Layout/>}>
          <Route index element={<Home/>}/>
          <Route path="/rules" element={<Rules/>}/>
          <Route path="/search" element={<Search/>}/>
          <Route path="/regulations" element={<Regulations/>}/>
          <Route path='/contact' element={<ContactForm/>} />
          <Route path="/login" element={<Login/>}/>
          <Route path="/signup" element={<Signup/>}/>
          <Route path="/category" element={<Category/>}/>
          <Route path="/:categoryMetalTile/:categoryId" element={<CategoryDetail/>}/>
          <Route path="/manager/novel/:authorId" element={<ManagerNovel/>}/>
          <Route path="/manager/novel/create/:authorId" element={<CreateNovel/>}/>
          <Route path="/manager/novel/edit/:novelId" element={<EditNovel/>} />
          <Route path="/manager/novel/:novelId/create-chapter" element={<ChapterCreate/>}/>
          <Route path="/manager/chapter/:novelId" element={<ListChapterNovel/>} />
          <Route path="/novel/:novelMetalTitle/:novelId" element={<NovelDetail/>}/>
          <Route path='/novel/:novelMetalTitle/:novelId/de-cu' element={<Nomination/>}/>
          <Route path='/novel/:novelMetalTitle/:novelId/de-cu/add' element={<CreateNomination/>}/>
          <Route path='/novel/:novelMetalTitle/:novelId/binh-luan' element={<Comments/>}/>
          <Route path='/novel/:novelMetalTitle/:novelId/binh-luan/add/:userId' element={<CreateComments/>}/>
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