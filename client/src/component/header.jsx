import React, { useEffect, useState } from "react";
import { Button, Flex } from "antd";
import { useNavigate } from "react-router-dom";

export const Header = () => {
  const [currentUser, setCurrentUser] = useState(null);
  const navigate = useNavigate();
  //fetch user name
  useEffect(() => {
    const fetchUser = () => {
      try {
        const storedUser = sessionStorage.getItem("userData");
        setCurrentUser(storedUser ? JSON.parse(storedUser) : null);
      } catch (error) {
        console.error("Lỗi khi lấy dữ liệu từ sessionStorage", error);
        setCurrentUser(null);
      }
    };
    fetchUser();
    const handleUserUpdate = () => fetchUser();
    window.addEventListener("userUpdated", handleUserUpdate);
    return () => window.removeEventListener("userUpdated", handleUserUpdate);
  }, []);

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
          {currentUser ? (
            <>
              <div>{currentUser.user}</div>
            </>
          ) : (
            <Flex gap="small" wrap>
              <Button onClick={() => navigate("/register")}>Đăng ký</Button>
              <Button type="primary" onClick={() => navigate("/login")}>
                Đăng nhập
              </Button>
            </Flex>
          )}
        </div>
      </div>
    </>
  );
};
