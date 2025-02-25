import React from "react";
import { useState } from "react";
import {
  Button,
  Checkbox,
  Form,
  Input,
  DatePicker,
  message,
  Table,
  Tag,
} from "antd";
import { Data } from "../data/data";
import dayjs from "dayjs";
const Test = () => {
  const columns = [
    {
      title: "Date",
      dataIndex: "date",
      key: "date",
      render: (date) => dayjs(date).format("YYYY-MM-DD HH:mm"), // Định dạng ngày giờ
    },
    {
      title: "Temperature (°C)",
      dataIndex: "temperatureC",
      key: "temperatureC",
    },
    {
      title: "Temperature (°F)",
      dataIndex: "temperatureF",
      key: "temperatureF",
    },
    {
      title: "Summary",
      dataIndex: "summary",
      key: "summary",
      render: (summary) => {
        let color =
          summary === "Freezing"
            ? "blue"
            : summary === "Bracing"
            ? "red"
            : "green";
        return <Tag color={color}>{summary}</Tag>;
      },
    },
  ];
  const onFinish = (values) => {
    console.log("Success:", values);
  };
  const onFinishFailed = (errorInfo) => {
    console.log("Failed:", errorInfo);
  };
  return (
    <>
      <div style={{ maxWidth: 800, margin: "50px auto" }}>
        <h2 style={{ textAlign: "center" }}>Weather Forecast</h2>
        <Table columns={columns} dataSource={Data} rowKey="date" />
        <Form />
      </div>
      <div className="w-full flex items-center justify-center">
        <Form
          name="basic"
          labelCol={{
            span: 8,
          }}
          wrapperCol={{
            span: 16,
          }}
          className="w-[700px] h-[200px] p-4"
          initialValues={{
            remember: true,
          }}
          onFinish={onFinish}
          onFinishFailed={onFinishFailed}
          autoComplete="off"
        >
          <Form.Item
            label="Username"
            name="username"
            rules={[
              {
                required: true,
                message: "Please input your username!",
              },
            ]}
          >
            <Input />
          </Form.Item>

          <Form.Item
            label="Password"
            name="password"
            rules={[
              {
                required: true,
                message: "Please input your password!",
              },
            ]}
          >
            <Input.Password />
          </Form.Item>

          <Form.Item name="remember" valuePropName="checked" label={null}>
            <Checkbox>Remember me</Checkbox>
          </Form.Item>

          <Form.Item label={null}>
            <Button type="primary" htmlType="submit">
              Submit
            </Button>
          </Form.Item>
        </Form>
      </div>
    </>
  );
};

export default Test;
