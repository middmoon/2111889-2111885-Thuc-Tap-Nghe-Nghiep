import React from "react";
import { imageList } from "../data/data";
import { useState, useEffect } from "react";
import { format } from "date-fns";
import axios from "axios";
const shuffleArray = (array) => {
  let shuffled = [...array];
  for (let i = shuffled.length - 1; i > 0; i--) {
    const j = Math.floor(Math.random() * (i + 1));
    [shuffled[i], shuffled[j]] = [shuffled[j], shuffled[i]];
  }
  return shuffled;
};

const PostList = () => {
  const [randomImages, setRandomImages] = useState([]);
  const [blogs, setBlogs] = useState([]);
  //Effect, API call
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
  return (
    <div className="flex flex-col  min-h-screen ">
      <div className="w-full flex md:flex-row flex-col  gap-3">
        <div
          className="flex-1  p-2 rounded-lg"
          style={{ boxShadow: "rgba(0, 0, 0, 0.35) 0px 5px 15px" }}
        >
          <p className="!mb-0 text-[14px] font-[600]">
            Tất cả bài viết của tôi
          </p>
          <div
            className="p-2 w-full rounded-lg  flex flex-wrap gap-3  max-h-[900px] overflow-y-auto"
            style={{
              scrollbarWidth: "none",
              msOverflowStyle: "none",
            }}
          >
            {blogs.slice(2).map((article, index) => (
              <div
                key={index}
                className="flex flex-col gap-1 md:w-[calc(50%-6px)]  bg-white rounded-lg p-2 border-[2px] "
              >
                <img
                  className="w-full max-h-[100px] rounded-lg object-cover"
                  src={randomImages[index]}
                  alt={article.title}
                />
                <p className="text-[14px] font-[600] !mb-0">{article.title}</p>
                <p className="!mb-0 text-[10px] text-gray-600">
                  {" "}
                  {article?.createdAt
                    ? format(new Date(article.createdAt), "yyyy-MM-dd")
                    : "N/A"}
                </p>
                <p className="!mb-0 text-[14px] text-gray-600 line-clamp-3">
                  {article.content}
                </p>
              </div>
            ))}
          </div>
        </div>
        <div
          className="flex-1 p-2 rounded-lg"
          style={{ boxShadow: "rgba(0, 0, 0, 0.35) 0px 5px 15px" }}
        >
          <p className="!mb-0 text-[14px] font-[600]">
            Bài viết đang chờ xét duyệt
          </p>
          <div
            className="p-2 w-full rounded-lg  flex flex-wrap gap-3  max-h-[900px] overflow-y-auto"
            style={{
              scrollbarWidth: "none",
              msOverflowStyle: "none",
            }}
          >
            {blogs.slice(2).map((article, index) => (
              <div
                key={index}
                className="flex flex-col gap-1 md:w-[calc(50%-6px)]  bg-white rounded-lg p-2 border-[2px] "
              >
                <img
                  className="w-full max-h-[100px] rounded-lg object-cover"
                  src={randomImages[index]}
                  alt={article.title}
                />
                <p className="text-[14px] font-[600] !mb-0">{article.title}</p>
                <p className="!mb-0 text-[10px] text-gray-600">
                  {" "}
                  {article?.createdAt
                    ? format(new Date(article.createdAt), "yyyy-MM-dd")
                    : "N/A"}
                </p>
                <p className="!mb-0 text-[14px] text-gray-600 line-clamp-3">
                  {article.content}
                </p>
              </div>
            ))}
          </div>
        </div>
      </div>
    </div>
  );
};

export default PostList;
