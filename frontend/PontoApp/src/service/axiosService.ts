import axios, { AxiosInstance } from 'axios';

class AxiosService {
  api: AxiosInstance;

  constructor(intance: AxiosInstance) {
    this.api = intance;
  }

  async get<T>(url: string) {
    const result = await this.api.get<T>(url);
    console.log(result.data);
    return result.data;
  }

  async postFormData<T>(url: string, dados: FormData) {
    const result = await this.api.post<T>(url, dados);
    return result.data;
  }
}

const axiosService = () =>
  new AxiosService(
    axios.create({ baseURL: 'https://localhost:7066/', timeout: 1000 })
  );

export default axiosService;
