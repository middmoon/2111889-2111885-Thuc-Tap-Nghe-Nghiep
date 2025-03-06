import React, { useEffect, useState } from "react";
import { message, List } from "antd";
import PendingBlog from "../component/pendingBlog";
import axiosClient from "../utils/axiosClient";
import withLayout from "../layout/withLayout";

const PendingBlogPage = () => {
  const [blogs, setBlogs] = useState([]);

  useEffect(() => {
    const fetchBlogs = async () => {
      try {
        const response = await axiosClient.get("/blogs/pending-approval");
        setBlogs(response.data);
      } catch (error) {
        console.log(error);
        message.error("Lỗi tải danh sách bài viết");
      }
    };
    fetchBlogs();
  }, []);

  const handleApprove = (id) => {
    setBlogs((prevBlogs) => prevBlogs.filter((blog) => blog.id !== id));
  };

  return (
    <>
      <div className="flex justify-center mt-5">
        <div className="w-3/5 max-w-2xl">
          <List dataSource={blogs} renderItem={(blog) => <PendingBlog key={blog.id} blog={blog} onApprove={handleApprove} />} />
        </div>
      </div>
    </>
  );
};

export default withLayout(PendingBlogPage);
