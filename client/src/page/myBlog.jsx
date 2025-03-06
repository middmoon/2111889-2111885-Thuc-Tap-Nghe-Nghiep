import React from "react";
import withLayout from "../layout/withLayout";
import PostList from "../component/postList";
const MyBlog = () => {
  return (
    <div className="w-full flex flex-col justify-center items-center">
      <div className=" max-w-[1500px] w-full">
        <PostList />
      </div>
    </div>
  );
};

export default withLayout(MyBlog);
