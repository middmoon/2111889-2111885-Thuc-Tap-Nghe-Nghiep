import React from "react";
import { Layout, Menu, Card, Row, Col, Typography, Image } from "antd";
import {
  TwitterOutlined,
  InstagramOutlined,
  GithubOutlined,
} from "@ant-design/icons";

const { Header, Content } = Layout;
const { Title, Text } = Typography;

const articles = [
  {
    title: "Eksplorasi design untuk melamar pekerjaan UI Designer",
    date: "January 11, 2022",
    description:
      "Belum pernah mengerjakan project tapi sering melakukan eksplorasi design...",
    image: "/assets/featured1.jpg",
  },
  {
    title:
      "Mungkin yang kamu butuhkan saat ini bukan lagi latihan tapi terjun ke industri",
    date: "March 27, 2022",
    image: "/assets/featured2.jpg",
  },
  {
    title: "Proses membuat layout dan komposisi pada UI Design",
    date: "February 15, 2022",
    image: "/assets/featured3.jpg",
  },
  {
    title: "Pertimbangkan branding sebelum menambahkan faktor delightful",
    date: "March 8, 2022",
    image: "/assets/featured4.jpg",
  },
];

const latestArticles = [
  {
    title: "Referensi Design 02: Halaman detail artikel pada blog",
    date: "March 22, 2022",
    image: "/assets/latest1.jpg",
  },
  {
    title: "Referensi Design 01: Bold Number pada design landing page",
    date: "March 22, 2022",
    image: "/assets/latest2.jpg",
  },
  {
    title: "Kapan menggunakan Switch atau Single Checkbox?",
    date: "March 25, 2022",
    image: "/assets/latest3.jpg",
  },
];

const ticlesPage = () => {
  return (
    <Layout className="min-h-screen bg-gray-100">
      {/* 🔹 CONTENT */}
      <Content className="max-w-6xl mx-auto mt-10 px-4">
        {/* 🔸 FEATURED ARTICLES */}
        <Title level={3}>Featured Artikel</Title>
        <Row gutter={[16, 16]}>
          <Col span={12}>
            <Card
              cover={<Image src={articles[0].image} alt={articles[0].title} />}
            >
              <Text type="secondary">{articles[0].date}</Text>
              <Title level={4}>{articles[0].title}</Title>
              <Text>{articles[0].description}</Text>
            </Card>
          </Col>
          <Col span={12}>
            {articles.slice(1).map((article, index) => (
              <Card key={index} className="mb-4 flex">
                <Image width={100} src={article.image} alt={article.title} />
                <div className="ml-4">
                  <Text type="secondary">{article.date}</Text>
                  <Title level={5}>{article.title}</Title>
                </div>
              </Card>
            ))}
          </Col>
        </Row>

        <Title level={3} className="mt-10">
          Artikel Terbaru
        </Title>
        <Row gutter={[16, 16]}>
          {latestArticles.map((article, index) => (
            <Col span={8} key={index}>
              <Card cover={<Image src={article.image} alt={article.title} />}>
                <Text type="secondary">{article.date}</Text>
                <Title level={5}>{article.title}</Title>
              </Card>
            </Col>
          ))}
        </Row>
      </Content>
    </Layout>
  );
};

export default ticlesPage;
// const Test = async () => {
//   try {
//     const headers = {
//       "Content-Type": "application/json",
//       Authorization: `Bearer ${accessToken}`,
//     };
//     const response = await axios.get(
//       "https://localhost:5001/api/test/protected/reader",
//       { withCredentials: true, headers: headers }
//     );
//     console.log("Response:", response.data);
//   } catch (error) {
//     console.error("Error:", error);
//   }
// };
