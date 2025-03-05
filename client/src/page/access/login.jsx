import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import withLayout from "../../layout/withLayout";
import { Flex, Form, Input, Button } from "antd";
import { motion } from "framer-motion";
import { useDispatch, useSelector } from "react-redux";
import { loginUser } from "../../features/auth/authSlice";

const Login = () => {
  const [openError, setOpenError] = useState(false);
  const navigate = useNavigate();
  const dispatch = useDispatch();
  const { isAuthenticated, status } = useSelector((state) => state.auth);

  useEffect(() => {
    if (isAuthenticated && status === "succeeded") {
      navigate("/");
    }
  }, [isAuthenticated, status, navigate]);

  const onFinish = async (values) => {
    try {
      await dispatch(loginUser(values)).unwrap();
    } catch (err) {
      setOpenError(true);
      setTimeout(() => setOpenError(false), 3000);
      console.error("Login Failed:", err);
    }
  };

  const onFinishFailed = (errorInfo) => {
    console.log("Failed:", errorInfo);
    setOpenError(true);
    setTimeout(() => setOpenError(false), 3000);
  };

  return (
    <>
      <div className="flex justify-center items-center p-3">
        <Flex vertical justify="center" align="center" className="p-7 rounded-md " style={{ boxShadow: "rgba(0, 0, 0, 0.35) 0px 5px 15px" }}>
          <p className="pb-5 text-[25px]">Đăng nhập</p>
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
              label="Tên User: "
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
            className="!mb-0 absolute max-h-[40px] bottom-10 left-3/2 md:top-20 md:right-10 pt-3 pb-1 px-2 bg-red-500 text-white rounded-md"
          >
            Lỗi đăng nhập
          </motion.div>
        )}
      </div>
    </>
  );
};

export default withLayout(Login);
