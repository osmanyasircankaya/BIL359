<template>
  <section class="splash">
    <div>
      <h3 class="title my-5">
        BIL359
      </h3>
      <div class="form-group">
        <input class="form-control" type="text" placeholder="enter your key.." v-model="name"/>
        <div class="result">{{ result }}</div>
      </div>
    </div>
  </section>
</template>

<script>
import {mapGetters} from "vuex";
import {hello} from "~/shared/gateway";

export default {
  components: {},

  data: () => ({
    name: '',
    result: ''
  }),

  computed: {
    ...mapGetters(["userSession"])
  },

  mounted() {
    this.name = '';
  },

  watch: {
    name: async function (newName) {
      this.result = newName
        ? await hello(newName)
        : '';
    }
  }
}
</script>

<style>
.splash {
  min-height: 60vh;
  display: flex;
  justify-content: center;
  align-items: center;
  text-align: center;
}

.title {
  font-family: "Quicksand", "Source Sans Pro", -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, "Helvetica Neue", Arial, sans-serif;
  display: block;
  font-weight: 300;
  font-size: 90px;
  color: #35495e;
  letter-spacing: 1px;
}

.subtitle {
  font-weight: 300;
  font-size: 42px;
  color: #526488;
  word-spacing: 5px;
  padding-bottom: 15px;
}

.result {
  padding-top: 15px;
  height: 30px;
  line-height: 30px;
  font-size: 24px;
}
</style>
