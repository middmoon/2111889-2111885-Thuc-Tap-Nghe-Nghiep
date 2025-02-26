import React, { useEffect, useState } from "react";
import axios from "axios";
import {
  Button,
  Checkbox,
  Form,
  Input,
  DatePicker,
  message,
  Table,
  Tag,
} from "antd";
import { Data } from "../data/data";
import dayjs from "dayjs";
const Test = () => {
  const [data, setData] = useState([]);
  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axios.get(
          "https://localhost:5001/WeatherForecast"
        );
        setData(response.data);
      } catch (error) {
        console.error("Error fetching data:", error);
      } finally {
        console.log("Data fetched successfully:", data);
      }
    };

    fetchData();
  }, []);
  const columns = [
    {
      title: "Date",
      dataIndex: "date",
      key: "date",
      render: (date) => dayjs(date).format("YYYY-MM-DD HH:mm"),
    },
    {
      title: "Temperature (°C)",
      dataIndex: "temperatureC",
      key: "temperatureC",
    },
    {
      title: "Temperature (°F)",
      dataIndex: "temperatureF",
      key: "temperatureF",
    },
    {
      title: "Summary",
      dataIndex: "summary",
      key: "summary",
      render: (summary) => {
        let color =
          summary === "Freezing"
            ? "blue"
            : summary === "Bracing"
            ? "cyan"
            : summary === "Chilly"
            ? "purple"
            : summary === "Cool"
            ? "geekblue"
            : summary === "Mild"
            ? "green"
            : summary === "Warm"
            ? "orange"
            : summary === "Balmy"
            ? "gold"
            : summary === "Hot"
            ? "volcano"
            : summary === "Sweltering"
            ? "red"
            : summary === "Scorching"
            ? "magenta"
            : "default";
        return <Tag color={color}>{summary}</Tag>;
      },
    },
  ];

  return (
    <>
      <div style={{ maxWidth: 800, margin: "50px auto" }}>
        <h2 style={{ textAlign: "center" }}>Weather Forecast</h2>
        <Table columns={columns} dataSource={data} rowKey="date" />
        <Form />
      </div>
    </>
  );
};

export default Test;
