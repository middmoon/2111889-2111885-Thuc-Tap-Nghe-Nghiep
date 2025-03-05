import React from "react";
import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import axios from "axios";
const Detail = () => {
  //state
  const { id } = useParams();
  const [blogData, setBlogData] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  //fetch blog
  useEffect(() => {
    const fetchBlog = async () => {
      try {
        const response = await axios.get(
          `https://localhost:5001/api/blogs/${id}`
        );
        setBlogData(response.data);
      } catch (error) {
        setError("Lỗi khi lấy dữ liệu!");
      } finally {
        setLoading(false);
      }
    };

    fetchBlog();
  }, [id]);
  if (loading) return <p>Đang tải...</p>;
  if (error) return <p>{error}</p>;
  return (
    <div className="w-full ">
      <div className="mt-[2%] flex flex-col justify-center items-center gap-3 ">
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
      <div className="flex flex-col justify-center items-center gap-3 mt-[2%]">
        {" "}
        <img
          className="max-h-[300px] w-full object-cover "
          src="/assets/home/high.webp"
          alt=""
        />
        <p className="text-justify mt-[1%]">
          {" "}
          <span className="font-[500] text-[30px]">
            {blogData.content.split(" ").slice(0, 8).join(" ")}
          </span>
          <br />
          <br />
          {blogData.content.split(" ").slice(8).join(" ")}
        </p>
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
        <p className="text-justify">
          Trong những năm gần đây, trí tuệ nhân tạo (AI) đã trở thành một trong
          những yếu tố quan trọng nhất tác động đến thị trường lao động toàn
          cầu. Không còn là một khái niệm xa vời hay chỉ xuất hiện trong các bộ
          phim khoa học viễn tưởng, AI giờ đây đã len lỏi vào từng ngóc ngách
          của nền kinh tế, thay đổi từ những công việc đơn giản đến cả những
          lĩnh vực phức tạp nhất. Các tập đoàn công nghệ hàng đầu như Google,
          Microsoft, Tesla, và Amazon đang đầu tư hàng tỷ đô la vào AI, nhằm cải
          tiến sản phẩm, nâng cao hiệu suất lao động và thậm chí là thay đổi
          cách thức vận hành của doanh nghiệp. heo một báo cáo gần đây của Tổ
          chức Lao động Quốc tế (ILO), AI có thể thay thế tới 30% công việc hiện
          tại trong vòng 10 năm tới. Những ngành nghề bị ảnh hưởng nhiều nhất
          bao gồm sản xuất, dịch vụ khách hàng, và thậm chí cả lĩnh vực sáng tạo
          như viết lách, thiết kế đồ họa. Tuy nhiên, AI không chỉ lấy đi việc
          làm mà còn mở ra nhiều cơ hội mới. Các vị trí liên quan đến phát triển
          phần mềm AI, khoa học dữ liệu, an ninh mạng và quản lý hệ thống tự
          động hóa đang có nhu cầu ngày càng cao. Trong ngành sản xuất, các nhà
          máy thông minh ứng dụng AI để tối ưu hóa quy trình sản xuất, giảm
          thiểu sai sót và tiết kiệm chi phí nhân công. Robot tự động có thể đảm
          nhiệm các công việc lặp đi lặp lại với độ chính xác cao hơn con người.
          Điều này khiến một số công nhân mất việc, nhưng đồng thời cũng tạo ra
          nhu cầu lớn về kỹ sư bảo trì, lập trình viên robot và chuyên gia phân
          tích dữ liệu. Ở lĩnh vực dịch vụ khách hàng, AI chatbot và trợ lý ảo
          đang dần thay thế con người trong việc xử lý các yêu cầu đơn giản. Các
          hệ thống AI như ChatGPT có thể hỗ trợ khách hàng 24/7 mà không cần
          nghỉ ngơi, tiết kiệm đáng kể chi phí vận hành cho doanh nghiệp. Tuy
          nhiên, con người vẫn đóng vai trò quan trọng trong những tình huống
          phức tạp đòi hỏi sự đồng cảm, linh hoạt và sáng tạo mà AI chưa thể đạt
          được.
        </p>
      </div>
    </div>
  );
};

export default Detail;
