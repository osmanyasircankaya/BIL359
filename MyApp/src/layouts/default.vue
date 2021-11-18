<template>
  <div>
    <link rel="stylesheet" href="/css/buttons.css">
    <link rel="stylesheet" href="/css/svg-auth.css">
    <link rel="stylesheet" href="/css/svg-icons.css">
    <div id="content" class="container">
      <nuxt/>
    </div>
    <div id="footer" style="text-align:center;width:100%;">
    </div>
  </div>
</template>

<script>
import {mapGetters} from "vuex";

export default {
  computed: {
    ...mapGetters(["nav", "userAttributes"])
  }
}
</script>
