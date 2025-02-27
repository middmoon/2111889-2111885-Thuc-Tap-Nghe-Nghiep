import React from "react";
import Test from "./page/test";
import Home from "./page/home";
import Login from "./page/access/login";
import Register from "./page/access/register";
import PostDetail from "./page/PostDetail";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
function App() {
  return (
    <div className="App">
      <Router>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/login" element={<Login />} />
          <Route path="/register" element={<Register />} />
          <Route path="/test" element={<Test />} />
          <Route path="/Detail" element={<PostDetail />} />
        </Routes>
      </Router>
    </div>
  );
}

export default App;
