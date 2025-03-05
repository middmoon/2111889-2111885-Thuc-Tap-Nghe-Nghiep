import React from "react";
import { Card, Typography, Image } from "antd";
import { format } from "date-fns";
import { useNavigate } from "react-router-dom";
import { motion } from "framer-motion";
import { imageList } from "../data/data";
import { useState, useEffect } from "react";
import axios from "axios";
import { LikeFilled } from "@ant-design/icons";
const { Title, Text } = Typography;
const shuffleArray = (array) => {
  let shuffled = [...array];
  for (let i = shuffled.length - 1; i > 0; i--) {
    const j = Math.floor(Math.random() * (i + 1));
    [shuffled[i], shuffled[j]] = [shuffled[j], shuffled[i]];
  }
  return shuffled;
};

const ArticlesPage = () => {
  //state
  const [currentUser, setCurrentUser] = useState(
    JSON.parse(sessionStorage.getItem("userData"))
  );
  const [randomImages, setRandomImages] = useState([]);
  const [likes, setLikes] = useState(false);
  const navigate = useNavigate();
  //Effect, API call
  const [blogs, setBlogs] = useState([]);

  const fetchBlogs = async () => {
    try {
      const response = await axios.get("https://localhost:5001/api/blogs");
      setBlogs(response.data);
    } catch (error) {
      console.error("Lỗi khi lấy dữ liệu blog:", error);
    }
  };
  //fetch blog
  useEffect(() => {
    fetchBlogs();
  }, []);
  //fetch random img
  useEffect(() => {
    let extendedImageList = [...imageList];
    while (extendedImageList.length < blogs.length - 2) {
      extendedImageList = [...extendedImageList, ...imageList];
    }
    const shuffledImages = shuffleArray(extendedImageList).slice(
      0,
      blogs.length - 2
    );
    setRandomImages(shuffledImages);
  }, []);
  //navigate
  const handleClick = (id) => {
    navigate(`/detail/${id}`);
  };
  //latesBlog
  const latestBlog = blogs?.reduce((latest, blog) => {
    return new Date(blog.createdAt) > new Date(latest.createdAt)
      ? blog
      : latest;
  }, blogs[0]);
  //Log test

  return (
    <>
      <div className="w-full h-[2px] bg-gray-300 mb-5" />
      <Title level={3}>Tổng hợp post</Title>
      <div className="flex flex-col md:flex-row gap-4">
        <motion.div
          initial={{ opacity: 0, y: 50 }}
          whileInView={{ opacity: 1, y: 0 }}
          transition={{ duration: 0.5 }}
          viewport={{ once: true, amount: 0.3 }}
          className="w-full md:w-1/2"
        >
          <Card
            cover={
              <Image
                src={imageList[0]}
                alt="1"
                className="w-full h-full max-h-[400px] object-cover"
              />
            }
          >
            <div className="flex w-full justify-between items-center">
              <div>
                {" "}
                <Text type="secondary">
                  <span className="font-bold ">Tác giả: </span>
                  {latestBlog?.author} <br />
                </Text>
                <Text type="secondary">
                  <span className="font-bold ">Ngày đăng: </span>
                  {latestBlog?.createdAt
                    ? format(new Date(latestBlog.createdAt), "yyyy-MM-dd")
                    : "N/A"}{" "}
                  <br />
                </Text>
                <Text type="secondary">
                  <span className="font-bold ">Lượt thích: </span>{" "}
                  {latestBlog?.likes}{" "}
                </Text>
              </div>
              <div>
                {currentUser && (
                  <LikeFilled
                    onClick={() => setLikes(!likes)}
                    className={`text-[30px] ${
                      likes ? "text-blue-500" : "text-gray-500"
                    }`}
                  />
                )}
              </div>
            </div>

            <Title
              level={4}
              onClick={() => handleClick(latestBlog?.id)}
              className="pt-2 cursor-pointer select-none"
            >
              {latestBlog?.title}
            </Title>
            <Text className="select-none">{latestBlog?.content}</Text>
          </Card>
        </motion.div>

        <motion.div
          initial={{ opacity: 0, y: 50 }}
          whileInView={{ opacity: 1, y: 0 }}
          transition={{ duration: 0.5, delay: 0.2 }}
          viewport={{ once: true, amount: 0.3 }}
          className="w-full md:w-1/2 flex flex-col gap-3 max-h-[700px] overflow-y-auto"
          style={{
            scrollbarWidth: "none",
            msOverflowStyle: "none",
          }}
        >
          {blogs.slice(2).map((article, index) => (
            <div
              key={index}
              className="flex flex-col sm:flex-row items-center gap-3 border p-3 "
              onClick={() => handleClick(article.id)}
            >
              {/* Hình ảnh */}
              <img
                src={randomImages[index]}
                alt={article.title}
                className="w-full sm:w-[150px] h-[150px] object-cover flex-shrink-0"
              />

              {/* Nội dung bài viết */}
              <div className="w-full sm:w-[calc(100%-160px)] flex flex-col justify-center">
                <Text type="secondary">
                  {" "}
                  {article?.createdAt
                    ? format(new Date(article.createdAt), "yyyy-MM-dd")
                    : "N/A"}
                </Text>
                <Title level={4} className="text-lg sm:text-xl cursor-pointer">
                  {article.title}
                </Title>
                <Text className="line-clamp-3">{article.content}</Text>
              </div>
            </div>
          ))}
        </motion.div>
      </div>
      <div className="w-full h-[2px] bg-gray-300 mt-5 mb-5" />
    </>
  );
};

export default ArticlesPage;
