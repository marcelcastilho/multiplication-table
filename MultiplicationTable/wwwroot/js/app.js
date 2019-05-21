Vue.component('matrix', {
    data: function () {
        return {
            rows: ['0']
        };
    },
    methods: {
        render: function () {
            axios
                .get('/api/multiplication-table?matrixSize=' + this.matrix_size + '&matrixBase=' + this.matrix_base)
                .then(response => this.rows = response.data);
        }
    },
    props: ['matrix_size', 'matrix_base'],
    template: '<table class="table table-bordered"><thead><tr class="text-center"><th scope="col">X</th><th class="table-active" scope="col" v-for="(cell, index) in rows[0]">{{ index + 1 }}</th></tr></thead><tbody><matrix-row v-for="(row, index) in rows" v-bind:row="row" v-bind:row_num="index" v-bind:matrix_base="matrix_base"></matrix-row></tbody></table> ',
    watch: {
        'matrix_size': function () {
            this.render();
        },
        'matrix_base': function () {
            this.render();
        }
    },
    mounted() {
        this.render();
    }
});

Vue.component('matrix-row', {
    props: ['row', 'row_num', 'matrix_base'],
    template: '<tr class="text-center"><th class="table-active" scope="row">{{ row_num + 1 }}</th><matrix-cell v-for="(value, index) in row" v-bind:value="value" v-bind:row_num="row_num" v-bind:col_num="index" v-bind:matrix_base="matrix_base"></matrix-cell></tr>'
});

Vue.component('matrix-cell', {
    props: ['value', 'row_num', 'col_num', 'matrix_base'],
    template: `<td v-bind:class="{ 'table-active': isDiagonal }" v-tooltip="calculation"><span v-bind:class="{ 'badge badge-info p-2': isPrime }">{{ value }}</span></td>`,
    computed: {
        decimalValue: function () {
            return parseInt(this.value, this.matrix_base);
        },
        isDiagonal: function () {
            return this.row_num === this.col_num;
        },
        isPrime: function () {
            for (var i = 2; i < this.decimalValue; i++)
                if (this.decimalValue % i === 0) return false;
            return this.decimalValue > 1;
        },
        calculation: function () {
            var value = parseInt(this.value, this.matrix_base);
            return this.row_num + 1 + 'X' + (this.col_num + 1) + '=' + this.decimalValue;
        }
    }
});

Vue.directive('tooltip', function (el, binding) {
    $(el).tooltip({
        title: binding.value,
        placement: 'top',
        trigger: 'hover'
    });
});

var app = new Vue({
    el: '#app',
    data: {
        matrix_size: '10',
        matrix_base: 10
    }
});
