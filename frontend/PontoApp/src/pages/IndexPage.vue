<template>
  <q-page>
    <div class="row items-center justify-center row">
      <div class="col-8">
        <q-card class="my-card q-mt-xl">
          <q-card-section>
            <q-card-section class="q-pt-xs">
              <div
                class="text-subtitle2 q-mt-sm q-mb-sm text-center"
                style="font-size: 18px"
              >
                Importar Horas
              </div>
              <div class="text-caption text-grey flex justify-center">
                <q-uploader
                  class="file-input"
                  label="Selecione ou araste os arquivos"
                  accept=".csv"
                  @added="(arquivos) => (files = arquivos)"
                >
                  <template v-slot:list="scope">
                    <div class="text-center">
                      <q-icon name="cloud_upload" color="grey" size="80px" />
                    </div>
                    Araste ou adicone

                    <q-list separator>
                      <q-item v-for="file in scope.files" :key="file.__key">
                        <q-item-section>
                          <q-item-label class="full-width ellipsis">
                            {{ file.name }}
                          </q-item-label>

                          <q-item-label caption>
                            Status: {{ file.__status }}
                          </q-item-label>

                          <q-item-label caption>
                            {{ file.__sizeLabel }} / {{ file.__progressLabel }}
                          </q-item-label>
                        </q-item-section>

                        <q-item-section
                          v-if="file.__img"
                          thumbnail
                          class="gt-xs"
                        >
                          <img :src="file.__img.src" />
                        </q-item-section>

                        <q-item-section top side>
                          <q-btn
                            class="gt-xs"
                            size="12px"
                            flat
                            dense
                            round
                            icon="delete"
                            @click="scope.removeFile(file)"
                          />
                        </q-item-section>
                      </q-item>
                    </q-list>
                  </template>
                </q-uploader>
              </div>
            </q-card-section>
          </q-card-section>

          <q-separator />

          <q-card-actions class="flex justify-end">
            <q-btn
              flat
              dense
              no-wrap
              color="primary"
              icon="cloud_upload"
              no-caps
              label="Upload CSV"
              class="q-ml-sm q-px-md"
              @click="() => filesUpload()"
            />
          </q-card-actions>
        </q-card>
      </div>
      <div class="col-12" v-if="dados">
        <q-card class="my-card q-mt-xl">
          <div class="q-pa-md">
            <q-table
              grid
              flat
              bordered
              card-class="bg-primary text-white"
              title="Horas Trabalhadas"
              :rows="dados"
              :columns="columns"
              row-key="dataDoRegistro"
              :filter="filtro"
              hide-header
            >
              <template v-slot:top-right>
                <q-input
                  v-model="filtro"
                  borderless
                  dense
                  debounce="300"
                  placeholder="Filtar"
                >
                  <template v-slot:append>
                    <q-icon name="search" />
                  </template>
                </q-input>
              </template>
            </q-table>
          </div>
        </q-card>
      </div>
    </div>
  </q-page>
</template>

<script lang="ts">
import { useQuasar } from 'quasar';
import { QSpinnerGears } from 'quasar';
import axiosService from 'src/service/axiosService';
import { defineComponent, ref } from 'vue';
import IDepartamento from 'src/interfaces/IDepartamento';
import IDiaTrabalhado from 'src/interfaces/IDiaTrabalhado';

export default defineComponent({
  name: 'IndexPage',
  components: {},
  setup() {
    const files = ref<readonly any[]>([]);
    const api = axiosService();
    const $q = useQuasar();
    const dados = ref();
    const filtro = ref();

    const columns: any[] = [
      {
        name: 'dataDoRegistro',
        required: true,
        label: 'Dia Trabalhado',
        align: 'center',
        field: (row: IDiaTrabalhado) => row.dataDoRegistro,
        format: (val: any) => `${new Date(val).toLocaleDateString('pt-BR')}`,
        sortable: true,
      },
      {
        name: 'horaDaEntrada',
        required: true,
        label: 'Horario Entrada',
        align: 'center',
        field: (row: IDiaTrabalhado) => row.horaDaEntrada,
        format: (val: any) => `${val}`,
        sortable: true,
      },
      {
        name: 'horaEntradaAlmoco',
        required: true,
        label: 'horaEntradaAlmoco',
        align: 'center',
        field: (row: IDiaTrabalhado) => row.horaEntradaAlmoco,
        format: (val: any) => `${val}`,
        sortable: true,
      },
      {
        name: 'horaSaidaAlmoco',
        required: true,
        label: 'horaSaidaAlmoco',
        align: 'center',
        field: (row: IDiaTrabalhado) => row.horaSaidaAlmoco,
        format: (val: any) => `${val}`,
        sortable: true,
      },
      {
        name: 'horaDaSaida',
        required: true,
        label: 'horaDaSaida',
        align: 'center',
        field: (row: IDiaTrabalhado) => row.horaDaSaida,
        format: (val: any) => `${val}`,
        sortable: true,
      },
    ];

    async function filesUpload() {
      $q.loading.show({
        spinner: QSpinnerGears,
        spinnerSize: 140,
        message: 'Processando a planilha...',
      });

      const formData = new FormData();

      formData.append('Arquivo', files.value[0]!);
      formData.append('Usuario', 'Matheus');

      try {
        const result = await api.postFormData<IDepartamento>(
          'api/Departamento/ObterDadosDepartamentoCSV',
          formData
        );

        dados.value = result.funcionarios[0].diasTrabalhados;

        $q.notify({
          message: 'Importação realizada com sucesso !',
          caption: `Finalizado em ${new Date().toLocaleDateString(
            'pt-BR'
          )} ${new Date().toLocaleTimeString('pt-BR')}`,
          position: 'top',
          color: 'green',
          timeout: 5000,
          progress: true,
          closeBtn: false,
          type: 'positive',
        });
      } catch (error) {
        $q.notify({
          type: 'negative',
          message: 'Houve um erro durante o processo de importação',
          caption: `Finalizado em ${new Date().toLocaleDateString(
            'pt-BR'
          )} ${new Date().toLocaleTimeString('pt-BR')}`,
          position: 'center',
          timeout: 5000,
          progress: true,
        });
      }
      $q.loading.hide();
    }
    return { filesUpload, files, dados, columns, filtro };
  },
});
</script>

<style scoped>
.file-input {
  width: 80%;
  height: 300px;
}
</style>
