import React from "react";
import { Form, Input, Button, message } from "antd";
import axiosClient from "../utils/axiosClient";
const CreateArticle = () => {
  const [form] = Form.useForm();

  const handleSubmit = async (values) => {
    console.log("Dữ liệu gửi đi:", values);

    try {
      const response = await axiosClient.post(
        "https://localhost:5001/api/blogs",
        values,
        {
          withCredentials: true,
        }
      );
      console.log("Response:", response.data);
      message.success("Bài viết đã được đăng!");
      form.resetFields();
    } catch (error) {
      console.error("Error:", error);
    }
  };

  return (
    <div className="flex justify-center items-center min-h-screen bg-gray-100">
      <div className="w-full max-w-2xl bg-white p-6 md:p-8 shadow-lg rounded-2xl">
        <h2 className="text-2xl md:text-4xl font-semibold text-center mb-6">
          Bắt đầu tạo bài viết của bạn
        </h2>
        <Form
          form={form}
          layout="vertical"
          className="space-y-4"
          onFinish={handleSubmit}
        >
          <Form.Item
            label={<span className="font-medium">Tiêu đề</span>}
            name="title"
            rules={[{ required: true, message: "Vui lòng nhập tiêu đề!" }]}
          >
            <Input
              placeholder="Nhập tiêu đề..."
              className="p-2 border rounded-lg w-full"
            />
          </Form.Item>

          <Form.Item
            label={<span className="font-medium">Nội dung</span>}
            name="content"
            rules={[{ required: true, message: "Vui lòng nhập nội dung!" }]}
          >
            <Input.TextArea
              rows={5}
              placeholder="Nhập nội dung..."
              className="p-2 border rounded-lg w-full"
            />
          </Form.Item>

          <Form.Item className="flex justify-center">
            <Button
              type="primary"
              htmlType="submit"
              className="px-6 py-2 text-lg bg-blue-600 hover:bg-blue-700 rounded-lg"
            >
              Gửi bài viết
            </Button>
          </Form.Item>
        </Form>
      </div>
    </div>
  );
};

export default CreateArticle;
