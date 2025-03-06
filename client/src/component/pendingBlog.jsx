import React from "react";

const PendingBlog = () => {
  return (
    <div className="flex flex-col  min-h-screen ">
      <div className="w-full flex gap-3">
        <div className="flex-1 bg-red-500 p-2 rounded-lg" style={{ boxShadow: "rgba(0, 0, 0, 0.35) 0px 5px 15px" }}>
          <p className="!mb-0 text-[14px] font-[600]">Tất cả bài viết của tôi</p>
          <div className="p-2 w-full rounded-lg border-[1px] border-dashed flex flex-wrap gap-3">
            <div className="w-[calc(50%-6px)] h-[200px] bg-white rounded-lg">a</div>
            <div className="w-[calc(50%-6px)] h-[200px] bg-white rounded-lg">a</div>
            <div className="w-[calc(50%-6px)] h-[200px] bg-white rounded-lg">a</div>
            <div className="w-[calc(50%-6px)] h-[200px] bg-white rounded-lg">a</div>
          </div>
        </div>
        <div className="flex-1 bg-green-500 p-2 rounded-lg" style={{ boxShadow: "rgba(0, 0, 0, 0.35) 0px 5px 15px" }}>
          a
        </div>
      </div>
    </div>
  );
};

export default PendingBlog;
