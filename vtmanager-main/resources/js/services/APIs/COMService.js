import http from "@/utils/http";

export const getDailySchedule = async () => {
  try {
    const result = await http.get("/com/main/schedule");
    return result?.data;
  } catch (error) {
    console.log(error);
  }
};
