import React from "react";
import { Button, Flex } from "antd";
import { useNavigate } from "react-router-dom";

export const Header = () => {
  const navigate = useNavigate();
  return (
    <>
      <div className="w-full flex justify-center items-center">
        <div className="flex justify-between items-center w-full max-h-[200px] max-w-[1500px] p-3">
          <p
            onClick={() => navigate("/")}
            className="flex justify-center items-center text-[20px] px-3  rounded-[50px] bg-blue-500 text-white"
          >
            B
          </p>
          <Flex gap="small" wrap>
            <Button onClick={() => navigate("/register")}>Đăng ký</Button>
            <Button type="primary" onClick={() => navigate("/login")}>
              Đăng nhập
            </Button>
          </Flex>
        </div>
      </div>
    </>
  );
};
