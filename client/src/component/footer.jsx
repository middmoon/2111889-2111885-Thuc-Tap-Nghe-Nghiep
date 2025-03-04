const Footer = () => {
  return (
    <footer className="bg-gray-900 text-white py-10 mt-10">
      <div className="container mx-auto grid grid-cols-1 md:grid-cols-3 gap-8 text-center md:text-left">
        {/* Cột 1: Giới thiệu */}
        <div>
          <h2 className="text-lg font-bold">Khám phá thiết kế</h2>
          <p className="text-sm mt-2">
            Hành trình trở thành UI Designer, chia sẻ kinh nghiệm, kiến thức và
            các xu hướng thiết kế mới nhất.
          </p>
        </div>

        {/* Cột 2: Liên kết nhanh */}
        <div>
          <h2 className="text-lg font-bold">Liên kết nhanh</h2>
          <ul className="mt-2 space-y-2">
            <li>
              <a href="#" className="hover:text-gray-400">
                Trang chủ
              </a>
            </li>
            <li>
              <a href="#" className="hover:text-gray-400">
                Bài viết
              </a>
            </li>
            <li>
              <a href="#" className="hover:text-gray-400">
                Dự án
              </a>
            </li>
            <li>
              <a href="#" className="hover:text-gray-400">
                Liên hệ
              </a>
            </li>
          </ul>
        </div>

        {/* Cột 3: Mạng xã hội */}
        <div>
          <h2 className="text-lg font-bold">Theo dõi chúng tôi</h2>
          <div className="flex justify-center md:justify-start gap-4 mt-2">
            <a href="#" className="hover:text-gray-400">
              Facebook
            </a>
            <a href="#" className="hover:text-gray-400">
              Twitter
            </a>
            <a href="#" className="hover:text-gray-400">
              LinkedIn
            </a>
            <a href="#" className="hover:text-gray-400">
              Behance
            </a>
          </div>
        </div>
      </div>

      {/* Dòng bản quyền */}
      <div className="mt-8 text-center border-t border-gray-700 pt-4">
        <p className="text-xs">
          © 2025 Khám phá thiết kế. All rights reserved.
        </p>
      </div>
    </footer>
  );
};

export default Footer;
