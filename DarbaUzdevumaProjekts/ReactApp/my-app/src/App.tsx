import { Route, Routes } from 'react-router-dom';
import MainPage from './pages/mainpage';

function App() {
  return (
    <div className="App">
      <Routes> 
        <Route path="/" element = {<MainPage/>}/>
        <Route path="/detailed/:id" element = {<MainPage/>}/>
        
      </Routes>
    </div>
  );
}

export default App;
