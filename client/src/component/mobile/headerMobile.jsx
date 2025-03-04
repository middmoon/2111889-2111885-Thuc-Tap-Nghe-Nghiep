import { useState } from "react";
import { Button, Popup } from "antd-mobile";
import { useNavigate } from "react-router-dom";
import { UnorderedListOutlined } from "@ant-design/icons";
export default function MobileHeader({ currentUser, handleLogout }) {
  const navigate = useNavigate();
  const [visible, setVisible] = useState(false);

  return (
    <div className="w-full flex justify-center items-center">
      <div className="flex justify-between items-center w-full max-h-[200px] max-w-[1500px] p-3">
        <p
          onClick={() => navigate("/")}
          className="flex justify-center items-center text-[20px] px-3 rounded-[50px] bg-blue-500 text-white cursor-pointer"
        >
          B
        </p>
        {currentUser ? (
          <div className="flex gap-3 items-center justify-center">
            <Button color="primary" onClick={() => setVisible(true)}>
              {currentUser.user}
            </Button>
            <Popup
              visible={visible}
              onMaskClick={() => setVisible(false)}
              bodyStyle={{ padding: "20px", textAlign: "center" }}
            >
              {currentUser.roles?.includes("writer") && (
                <Button
                  block
                  style={{ marginBottom: 10 }}
                  onClick={() => navigate("/create-post")}
                >
                  Đăng bài
                </Button>
              )}
              <Button block color="danger" onClick={handleLogout}>
                Đăng xuất
              </Button>
            </Popup>
          </div>
        ) : (
          <>
            <Button color="primary" onClick={() => setVisible(true)}>
              <UnorderedListOutlined />
            </Button>
            <Popup
              visible={visible}
              onMaskClick={() => setVisible(false)}
              bodyStyle={{ padding: "20px", textAlign: "center" }}
            >
              <Button
                block
                style={{ marginBottom: 10 }}
                onClick={() => navigate("/register")}
              >
                Đăng ký
              </Button>
              <Button block type="primary" onClick={() => navigate("/login")}>
                Đăng nhập
              </Button>
            </Popup>
          </>
        )}
      </div>
    </div>
  );
}
