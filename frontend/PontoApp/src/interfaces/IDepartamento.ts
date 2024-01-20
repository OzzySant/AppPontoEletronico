import IFuncionario from './IFuncionario';

export default interface IDepartamento {
  nome: string;
  mes: string;
  ano: number;
  funcionarios: IFuncionario[];
}
