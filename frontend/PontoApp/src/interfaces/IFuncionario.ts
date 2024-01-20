import IDiaTrabalhado from './IDiaTrabalhado';

export default interface IFuncionario {
  codigo: number;
  nome: string;
  valorDaHora: number;
  diasTrabalhados: IDiaTrabalhado[];
}
