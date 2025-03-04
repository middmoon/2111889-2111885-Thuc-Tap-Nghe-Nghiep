import React, { useEffect, useState } from "react";
import { Button, Flex } from "antd";
import { useNavigate } from "react-router-dom";
import { useDevice } from "../hooks/useDevice";
import MobileHeader from "./mobile/headerMobile";
import { axiosClient } from "../utils/axiosClient";
import { logoutUser } from "../features/auth/authSlice";
import { useDispatch, useSelector } from "react-redux";

export const Header = () => {
  const [currentUser, setCurrentUser] = useState(null);
  const [isOpen, setIsOpen] = useState(false);
  const navigate = useNavigate();
  const { isMobile } = useDevice();
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

  //logout
  // const handleLogout = () => {
  //   sessionStorage.removeItem("userData");
  //   window.dispatchEvent(new Event("userUpdated"));
  //   navigate("/");
  // };

  // console.log(currentUser?.roles);

  // logout using redux

  const dispatch = useDispatch();
  const isAuthenticated = useSelector((state) => state.auth.isAuthenticated);

  const handleLogout = () => {
    dispatch(logoutUser());
    navigate("/");
  };

  useEffect(() => {
    if (!isAuthenticated) {
      setCurrentUser(null);
    }
  }, [isAuthenticated]);

  return (
    <>
      {isMobile ? (
        <MobileHeader currentUser={currentUser} handleLogout={handleLogout} />
      ) : (
        <div className="w-full flex justify-center items-center">
          <div className="flex justify-between items-center w-full max-h-[200px] max-w-[1500px] p-3">
            <p onClick={() => navigate("/")} className="flex justify-center items-center text-[20px] px-3  rounded-[50px] bg-blue-500 text-white">
              B
            </p>
            {currentUser ? (
              <>
                <div className="flex gap-3 items-center justify-center">
                  <div className="text-[14px]" onClick={() => setIsOpen(!isOpen)}>
                    Hello, {currentUser.user}
                  </div>
                  {currentUser.roles?.includes("writer") && <Button onClick={() => navigate("/create-post")}>Đăng bài</Button>}
                  <Button onClick={handleLogout}>Đăng xuất</Button>
                </div>
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
      )}
    </>
  );
};
