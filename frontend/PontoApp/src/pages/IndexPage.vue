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
                />
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
    </div>
  </q-page>
</template>

<script lang="ts">
import { useQuasar } from 'quasar';
import axiosService from 'src/service/axiosService';
import { defineComponent, ref } from 'vue';

export default defineComponent({
  name: 'IndexPage',
  components: {},
  setup() {
    const files = ref<readonly any[]>([]);
    const api = axiosService();
    const $q = useQuasar();

    async function filesUpload() {
      const formData = new FormData();

      formData.append('Arquivo', files.value[0]!);
      formData.append('Usuario', 'Matheus');
      try {
        const result = await api.postFormData<any>(
          'api/Departamento/ObterDadosDepartamentoCSV',
          formData
        );
        $q.notify({
          message: 'Importação realizada com sucesso !',
          caption: `${new Date().toLocaleDateString(
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
          caption: `${new Date().toLocaleDateString(
            'pt-BR'
          )} ${new Date().toLocaleTimeString('pt-BR')}`,
          position: 'center',
          timeout: 5000,
          progress: true,
        });
      }
    }
    return { filesUpload, files };
  },
});
</script>

<style scoped>
.file-input {
  width: 80%;
  height: 150px;
}
</style>
