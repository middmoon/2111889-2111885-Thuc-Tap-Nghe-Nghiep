import React, { useEffect, useState } from "react";
import { Button, Flex, Dropdown, Space, DownOutlined } from "antd";
import { useNavigate } from "react-router-dom";
import { useDevice } from "../hooks/useDevice";
import MobileHeader from "./mobile/headerMobile";
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

  console.log(currentUser);
  // logout using redux

  const dispatch = useDispatch();

  const handleLogout = async () => {
    await dispatch(logoutUser());
    setCurrentUser(null);
    navigate("/");
    window.location.reload();
  };

  //data
  const items = [
    {
      key: "profile",
      label: "Profile",
      onClick: () => navigate("/profile"),
    },

    ...(currentUser?.roles?.includes("writer")
      ? [
          {
            key: "5",
            label: "Đăng bài",
            onClick: () => navigate("/create-post"),
          },
        ]
      : []),
    ...(currentUser?.roles?.includes("admin")
      ? [
          {
            key: "6",
            label: "Duyệt bài",
            onClick: () => navigate("/create-post"),
          },
        ]
      : []),
    ...(currentUser?.roles?.includes("admin")
      ? [
          {
            key: "7",
            label: "Duyệt tác giả",
            onClick: () => navigate("/create-post"),
          },
        ]
      : []),
    ...(!currentUser?.roles?.includes("writer")
      ? [
          {
            key: "5",
            label: "Đăng kí tác giả",
          },
        ]
      : []),
    {
      type: "divider",
    },
    {
      key: "logout",
      label: "Đăng xuất",
      onClick: handleLogout,
    },
  ];
  return (
    <>
      {isMobile ? (
        <MobileHeader currentUser={currentUser} handleLogout={handleLogout} />
      ) : (
        <div className="w-full flex justify-center items-center">
          <div className="flex justify-between items-center w-full max-h-[200px] max-w-[1500px] p-3">
            <p
              onClick={() => navigate("/")}
              className="flex justify-center items-center text-[20px] px-3  rounded-[50px] bg-blue-500 text-white cursor-pointer"
            >
              B
            </p>
            {currentUser ? (
              <>
                <div className="flex gap-3 items-center justify-center">
                  {/* Dropdown Menu */}
                  <Dropdown menu={{ items }} trigger={["click"]}>
                    <a onClick={(e) => e.preventDefault()}>
                      <Space>Hello, {currentUser.user}</Space>
                    </a>
                  </Dropdown>
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
