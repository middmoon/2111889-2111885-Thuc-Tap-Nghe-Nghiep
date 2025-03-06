import React from "react";
import Test from "./page/test";
import Home from "./page/home";
import Login from "./page/access/login";
import Register from "./page/access/register";
import PostDetail from "./page/PostDetail";
import Counter from "./features/counter/counter";

import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import CreatePost from "./page/createPost";
import MyBlog from "./page/myBlog";
import PendingBlogPage from "./page/pendingBlog";

function App() {
  return (
    <div className="App">
      <Router>
        <Routes>
          {/* public route */}
          <Route path="/" element={<Home />} />
          <Route path="/login" element={<Login />} />
          <Route path="/register" element={<Register />} />
          <Route path="/test" element={<Test />} />
          <Route path="/detail/:id" element={<PostDetail />} />
          <Route path="/create-post" element={<CreatePost />} />
          <Route path="/redux-counter" element={<Counter />} />
          <Route path="/my-blogs" element={<MyBlog />} />
          <Route path="/pending-blogs" element={<PendingBlogPage />} />
        </Routes>
      </Router>
    </div>
  );
}

export default App;
