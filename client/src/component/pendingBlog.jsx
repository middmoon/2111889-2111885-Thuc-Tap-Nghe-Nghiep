import React from "react";
import { Card, Button, message } from "antd";
import axiosClient from "../utils/axiosClient";
import { format } from "date-fns";

const PendingBlog = ({ blog, onApprove }) => {
  const handleApprove = async () => {
    try {
      const response = await axiosClient.put(`/blogs/approve/${blog.id}`);
      if (response.status === 200) {
        message.success("Bài viết đã được duyệt");
        onApprove(blog.id);
      } else {
        message.error("Lỗi khi duyệt bài viết");
      }
    } catch (error) {
      message.error("Lỗi kết nối đến server");
    }
  };

  return (
    <Card title={blog.title} extra={<span>Tác giả: {blog.author}</span>} style={{ marginBottom: 16 }}>
      <p>Ngày đăng: {blog?.createdAt ? format(new Date(blog.createdAt), "yyyy-MM-dd") : "N/A"}</p>
      <br />
      <p>{blog.content}</p>
      <Button type="primary" onClick={handleApprove}>
        Duyệt bài
      </Button>
    </Card>
  );
};

export default PendingBlog;
