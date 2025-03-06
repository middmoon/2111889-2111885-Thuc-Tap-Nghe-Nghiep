import React, { useEffect, useState } from "react";
import withLayout from "../layout/withLayout";

import axiosClient from "../utils/axiosClient";

const PendingBlog = () => {
  const [pendingBlogs, setPendingBlogs] = useState([]);
  //fetch blog
  useEffect(() => {
    const fetchBlog = async () => {
      try {
        const response = await axiosClient.get("https://localhost:5001/api/blogs");
        setPendingBlogs(response.data);
      } catch (error) {
        console.error("Lỗi khi lấy dữ liệu blog:", error);
      }
    };
    fetchBlog();
  }, []);

  console.log(pendingBlogs);

  return (
    <div className="w-full flex flex-col justify-center items-center">
      <div className=" max-w-[1500px] w-full">
        <p>Đang chờ duyệt</p>
      </div>
    </div>
  );
};

export default withLayout(PendingBlog);
