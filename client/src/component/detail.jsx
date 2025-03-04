import withLayout from "../layout/withLayout";
import React from "react";
import { blogData } from "../data/data";
const Detail = () => {
  return (
    <div className="w-full ">
      <div className="mt-[6%] flex flex-col justify-center items-center gap-3 ">
        {" "}
        <p className=" text-gray-400">{blogData.date}</p>
        <p className="text-[40px] text-center font-bold">{blogData.title}</p>
        <div className="w-full flex justify-center items-center gap-2">
          <p class="flex justify-center items-center text-[20px] px-3  rounded-[50px] bg-blue-500 text-white">
            B
          </p>
          <p className="flex gap-1">
            Blog <span className="text-[10px]">pro</span>
          </p>
        </div>
      </div>
      <div className="flex flex-col justify-center items-center gap-3 mt-[5%]">
        {" "}
        <img
          className="max-h-[400px] w-full object-cover rounded-[40px]"
          src="/assets/home/high.webp"
          alt=""
        />
        <p className="text-justify mt-[2%]">
          {" "}
          <span className="font-[500] text-[30px]">
            {blogData.content.split(" ").slice(0, 10).join(" ")}
          </span>
          <br />
          <br />
          {blogData.content.split(" ").slice(10).join(" ")}
        </p>
        <p className="text-justify">{blogData.content}</p>
        <p className="text-justify">{blogData.content}</p>
        <div className="flex flex-col md:flex-row gap-3 w-full">
          <img
            className="flex-1  max-h-[200px] object-cover"
            src="/assets/home/tarnical2.webp"
            alt=""
          />
          <img
            className="flex-1  max-h-[200px] object-cover"
            src="/assets/home/working2.webp"
            alt=""
          />
        </div>
        <p className="text-justify">{blogData.content}</p>
      </div>
    </div>
  );
};

export default Detail;
