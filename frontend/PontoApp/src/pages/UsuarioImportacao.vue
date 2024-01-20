<template>
  <main
    @dragover="handleDragOver"
    @dragenter="handleDragEnter"
    @dragleave="handleDragLeave"
    @drop="handleDrop"
  >
    <!-- Your component content goes here -->
  </main>
</template>

<script>
export default {
  methods: {
    handleDragOver(e) {
      e.preventDefault();
    },
    handleDragEnter(e) {
      this.$refs.elem.style.outline = 'solid red 1px';
    },
    handleDragLeave(e) {
      this.$refs.elem.style.outline = '';
    },
    async handleDrop(e) {
      e.preventDefault();
      this.$refs.elem.style.outline = '';

      const supportsFileSystemAccessAPI =
        'getAsFileSystemHandle' in DataTransferItem.prototype;

      const fileHandlesPromises = [...e.dataTransfer.items]
        .filter((item) => item.kind === 'file')
        .map((item) =>
          supportsFileSystemAccessAPI
            ? item.getAsFileSystemHandle()
            : item.getAsFile()
        );

      for await (const handle of fileHandlesPromises) {
        if (handle.kind === 'file' || handle.isFile) {
          console.log(`File: ${handle.name}`);
        }
      }
    },
  },
};
</script>

<style scoped>
/* Your component styles go here */
</style>
