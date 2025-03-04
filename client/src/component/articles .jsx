import React from "react";
import { Layout, Card, Row, Col, Typography, Image } from "antd";
import { format } from "date-fns";
import { articles } from "../data/data";
import { motion } from "framer-motion";
import { imageList } from "../data/data";
import { useState, useEffect } from "react";
import axios from "axios";
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
  const [randomImages, setRandomImages] = useState([]);

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

  //Log test
  console.log(blogs);
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
            <Text type="secondary">Kungai ,</Text>
            <Text type="secondary">
              {blogs[0]?.createdAt
                ? format(new Date(blogs[0].createdAt), "yyyy-MM-dd")
                : "N/A"}
            </Text>

            <Title level={4}>{blogs[9]?.title}</Title>
            <Text>{blogs[9]?.content}</Text>
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
                <Title level={4} className="text-lg sm:text-xl">
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
