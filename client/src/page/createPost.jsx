import React from "react";
import CreateArticle from "../component/createArticle";
import withLayout from "../layout/withLayout";
const CreatePost = () => {
  return (
    <div className="w-full flex flex-col justify-center items-center">
      <div className=" max-w-[1500px] w-full">
        <CreateArticle />
      </div>
    </div>
  );
};

export default withLayout(CreatePost);
