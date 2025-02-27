import React from "react";
import withLayout from "../layout/withLayout";
import ArticlesPage from "../component/articles ";
const Home = () => {
  return (
    <div className="w-full flex flex-col justify-center items-center">
      <div className=" max-w-[1500px] w-full">
        <ArticlesPage />
      </div>
    </div>
  );
};

export default withLayout(Home);
