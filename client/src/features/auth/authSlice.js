import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axiosClient from "../../utils/axiosClient";

export const loginUser = createAsyncThunk("auth/login", async (credentials, { rejectWithValue }) => {
  try {
    const response = await axiosClient.post("/auth/login", credentials);
    sessionStorage.setItem("userData", JSON.stringify(response.data));
    return true;
  } catch (error) {
    return rejectWithValue(error.response?.data?.message || "Login failed");
  }
});

export const logoutUser = createAsyncThunk("auth/logout", async () => {
  await axiosClient.delete("/auth/logout");
  localStorage.removeItem("token");
  sessionStorage.removeItem("userData");
});

const authSlice = createSlice({
  name: "auth",
  initialState: { isAuthenticated: false, status: "idle", error: null },
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(loginUser.fulfilled, (state, action) => {
        console.log("Đng nhập thành công");
        state.isAuthenticated = true;
        state.status = "succeeded";
      })
      .addCase(loginUser.rejected, (state, action) => {
        console.log("Đăng nhập thất bại");
        state.isAuthenticated = false;
        state.error = action.payload;
      })
      .addCase(logoutUser.fulfilled, (state) => {
        console.log("Đăng xuất thành công");
        state.isAuthenticated = false;
      })
      .addCase(logoutUser.rejected, (state, action) => {
        console.log("Đăng xuất thất bại");
        state.isAuthenticated = true;
        state.error = action.payload;
      });
  },
});

export default authSlice.reducer;
