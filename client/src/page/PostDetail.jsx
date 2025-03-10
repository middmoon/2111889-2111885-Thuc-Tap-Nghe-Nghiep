import React from "react";
import withLayout from "../layout/withLayout";
import Detail from "../component/detail";
const PostDetail = () => {
  return (
    <div className="w-full flex flex-col justify-center items-center">
      <div className=" max-w-[1500px] w-full">
        <Detail />
      </div>
    </div>
  );
};

export default withLayout(PostDetail);
