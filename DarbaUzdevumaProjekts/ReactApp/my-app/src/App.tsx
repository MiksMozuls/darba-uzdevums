import { Route, Routes } from 'react-router-dom';
import MainPage from './pages/mainpage';
import DetailedView from './pages/detailedview';
import FromSource from './pages/fromsource';

function App() {
  return (
    <div className="App">
      <Routes> 
        <Route path="/" element = {<MainPage/>}/>
        <Route path="/detailed/:id" element = {<DetailedView/>}/>
        <Route path="/fromSource/:id" element = {<FromSource/>}/>
      </Routes>
    </div>
  );
}

export default App;
