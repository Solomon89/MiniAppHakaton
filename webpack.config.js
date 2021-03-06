const path = require('path');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const {CleanWebpackPlugin} = require('clean-webpack-plugin');
const BrowserSyncPlugin = require('browser-sync-webpack-plugin');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const CopyPlugin = require('copy-webpack-plugin');
const VueLoaderPlugin = require('vue-loader/lib/plugin');

const isDev = process.env.NODE_ENV === 'development';
const watchMode = process.env.WATCH === 'true';

const namingPattern = '[name]';
// const namingPattern = watchMode ? '[name]' : '[name].[contenthash]';


//настройки
const work_folder_name = "wwwroot/src";
// const output_folder_name = "wwwroot/dist";
const output_folder_name = "wwwroot/dist";

const PATHS = {
    src: path.resolve(__dirname, work_folder_name),
    dist: path.resolve(__dirname, output_folder_name),
};

module.exports = {
    entry: {
        //Чтобы соблюдать порядок вставки стилей лучше импортировать внутри js
        //но в теории можно добавить вторую точку входа
        //path.join(PATHS.src, 'scss', 'styles.scss')
        app: [path.join(PATHS.src, 'js', 'app.js')],
    },
    context: PATHS.src, //Входная папка
    output: {
        filename: `js/${namingPattern}.js`,
        path: PATHS.dist,   //Выходная папка
    },

    devtool: isDev ? 'source-map' : '',
    stats: {
        children: false
    },
    plugins: [
        new CleanWebpackPlugin({cleanStaleWebpackAssets: !watchMode}),
        new VueLoaderPlugin(),
        new MiniCssExtractPlugin({
            filename: `css/${namingPattern}.css`,
        }),

        //Ищет файлы в папке контекста (src)
        //копирует в выходную директорию
        
        // new CopyPlugin([
        //         {from: 'something.php', to: ''},
        //         {from: 'other.php', to: ''},
        //     ],
        //     {
        //         copyUnmodified: true
        //     }
        // ),

        // new HtmlWebpackPlugin({
        //     inject: false,  //Сам не вставляет, только по шаблону
        //     title: 'Project_Title',
        //     filename: 'index.html', //Вывод в выходную папку
        //     template: 'index.html', //Относительно входной папки(src)
        //     chunks: ['app'],    //вставляются стили и скрипты из входной точки app
        // }),
        new BrowserSyncPlugin(
            {
                // host: 'localhost',
                // port: 3000,
                proxy: 'https://localhost:5001/',
                notify: false
            },
            // plugin options
            {
                injectCss: true,
            }
        ),
    ],
    module: {
        rules: [
            {
                test: /\.vue$/,
                loader: 'vue-loader'
            },
            {
                test: /\.(html|php)$/,
                use: [
                    {
                        loader: 'ejs-loader',
                    },
                    {
                        loader: 'extract-loader',
                    },
                    {
                        loader: "html-loader",
                        options: {
                            minimize: !isDev
                        }
                    },

                ]
            },
            {
                test: /\.ts$/,
                use: ['babel-loader', 'ts-loader'],
                exclude: /node_modules/,
            },
            {
                test: /\.js$/,
                use: ["source-map-loader"],
                enforce: "pre"
            },
            {
                test: /\.js$/,
                exclude: /node_modules/,
                use: {
                    loader: 'babel-loader',
                }
            },
            {
                test: /\.css$/,
                use: [
                    {
                        loader: MiniCssExtractPlugin.loader,
                        options: {
                            publicPath: '../',
                        }
                    },
                    {
                        loader: "css-loader",
                        options: {sourceMap: true}
                    },
                    {
                        loader: "postcss-loader",
                        options: {sourceMap: true}
                    },
                    {
                        loader: "resolve-url-loader",
                        options: {sourceMap: true}
                    },
                ],
            },
            {
                test: /\.s[ac]ss$/,
                use: [
                    {
                        loader: MiniCssExtractPlugin.loader,
                        options: {
                            publicPath: '../',
                        }
                    },
                    {
                        loader: "css-loader",
                        options: {sourceMap: true}

                    },
                    {
                        loader: "postcss-loader",
                        options: {sourceMap: true}
                    },
                    {
                        loader: "resolve-url-loader",
                        options: {sourceMap: true}
                    },
                    {
                        loader: "sass-loader",
                        options: {
                            sourceMap: true,
                        }
                    },
                ],
            },
            {
                // assets
                test: /\.(png|jpg|gif|ico|svg|woff(2)?|ttf|eot|mp3)$/,
                loader: "file-loader",
                options: {
                    name: `${namingPattern}.[ext]`,
                    outputPath: '../dist/static'
                }
            },

        ],
    },
    resolve: {
        extensions: ['.js', '.vue'],
        alias: {
            'vue$': 'vue/dist/vue.esm.js',
            '@': path.join(__dirname, work_folder_name)
        }
    },
    mode: isDev ? 'development' : 'production',
    watch: watchMode,
    // optimization: {
    //     splitChunks: {
    //         chunks: 'all',
    //     }
    // },
};