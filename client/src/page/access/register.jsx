import React, { useState } from "react";
import withLayout from "../../layout/withLayout";
import { Flex, Form, Input, Button } from "antd";
import axios from "axios";
import { motion } from "framer-motion";

const Register = () => {
  const [openError, setOpenError] = useState(false);
  //register method
  const onFinish = async (values) => {
    try {
      const response = await axios.post(
        "https://localhost:5001/api/auth/register",
        values,
        { withCredentials: true }
      );
      console.log("Response:", response.data);
    } catch (error) {
      setOpenError(true);
      console.error("Error:", error);
      setTimeout(() => {
        setOpenError(false);
      }, 2000);
    }
  };
  const onFinishFailed = (errorInfo) => {
    console.log("Failed:", errorInfo);
  };
  return (
    <>
      <div className="w-full flex justify-center items-center p-3">
        <Flex
          vertical
          justify="center"
          align="center"
          className="p-7 rounded-md "
          style={{ boxShadow: "rgba(0, 0, 0, 0.35) 0px 5px 15px" }}
        >
          <p className="pb-5 text-[25px]">Đăng ký</p>
          <Form
            name="basic"
            labelCol={{
              xs: { span: 24 },
              sm: { span: 8 },
            }}
            wrapperCol={{
              xs: { span: 24 },
              sm: { span: 16 },
            }}
            style={{
              maxWidth: 700,
            }}
            initialValues={{
              remember: true,
            }}
            onFinish={onFinish}
            onFinishFailed={onFinishFailed}
            autoComplete="off"
          >
            <Form.Item
              label="Tên User"
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
              label="Mật khẩu"
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

            <Form.Item label={null}>
              <Button type="primary" htmlType="submit">
                Submit
              </Button>
            </Form.Item>
          </Form>
        </Flex>
        {openError && (
          <motion.div
            initial={{ opacity: 0, x: 50 }}
            whileInView={{ opacity: 1, x: 0 }}
            transition={{ duration: 0.5 }}
            viewport={{ once: true, amount: 0.3 }}
            className="absolute max-h-[40px] bottom-10 left-3/2 md:top-20 md:right-10 px-4 py-2 bg-red-500 text-white rounded-md"
          >
            Lỗi đăng ký
          </motion.div>
        )}
      </div>
    </>
  );
};

export default withLayout(Register);
