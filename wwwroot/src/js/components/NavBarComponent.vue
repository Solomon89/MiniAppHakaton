<template>
    <div class="nav-wrapper">
        <div class="nav-toggle">
            <div class="nav-toggle-bar"></div>
        </div>

        <nav id="nav" class="nav">
            <div class="profilePhoto">
                <img :src="profilePhotoUrl" alt="Ваше фото">
            </div>
            <span class="h2 mb-5 mt-1">Здравствуйте, {{profileName}}</span>

            <ul>
                <li><a :href="authUrl">Войти в STRAVA</a></li>
                <li><a>Маршруты</a></li>
                <li><a>События</a></li>
                <li><a>Кланы</a></li>
            </ul>
        </nav>

    </div>
</template>

<script>
    export default {
        name: "NavBarComponent",
        props: {
            profilePhotoUrl: String,
            profileName: String,
            vkId: Number

        },
        mounted() {
            let hamburger = {
                nav: document.querySelector('#nav'),
                navToggle: document.querySelector('.nav-toggle'),

                initialize() {
                    this.navToggle.addEventListener('click',
                        () => {
                            this.toggle();
                        });
                },

                toggle() {
                    this.navToggle.classList.toggle('expanded');
                    this.nav.classList.toggle('expanded');
                },
            };

            hamburger.initialize();
        },
        computed: {
            authUrl() {
                return `Strava/AuthInStrava?VkId=${this.vkId}`
            }
        }
    }
</script>

<style lang="scss" scoped>
    .nav-wrapper {
        z-index: 3;

    }

    /* colors */
    $colors: (
            primary: #5634d1,
            accent: #302B4E,
            black: #2b3742,
            white: #EF335A,
    );

    @function color($key) {
        @return map-get($colors, $key);
    }

    @function contrast-color($color,
	$dark: color(black), $light: color(white)) {
        @if (lightness($color) > 75) {
            @return $dark;
        } @else {
            @return $light;
        }
    }

    $colors: map-merge($colors, (
            text-dark: rgba(color(black), .75),
            text-light: rgba(color(white), .75),
    ));

    /* variables */
    $html-background: color(primary);
    $html-font: 'Source Sans Pro', Helvetica, Arial, sans-serif;
    $nav-background: color(accent);
    $nav-width: 70vw;
    $nav-z-index: 1;
    $nav-toggle-bar-height: 0.4rem;
    $nav-toggle-bar-width: 3.6rem;
    $nav-toggle-z-index: 2;

    /* mixins */
    @mixin center-vertically($position: absolute) {
        position: $position;
        top: 50%;
        transform: translateY(-50%);
    }

    @mixin transform($transform) {
        -ms-transform: $transform;
        -webkit-transform: $transform;
        transform: $transform;
    }

    a {
        color: inherit;
        cursor: pointer;
        text-decoration: none;

        &:hover {
            opacity: 0.8;
        }
    }

    /* nav toggle */
    .nav-toggle {
        cursor: pointer;
        height: 5 * $nav-toggle-bar-height;
        left: 2rem;
        position: fixed;
        top: 2rem;
        width: $nav-toggle-bar-width;
        z-index: $nav-toggle-z-index;

        &:hover {
            opacity: 0.8;
        }

        .nav-toggle-bar,
        .nav-toggle-bar::after,
        .nav-toggle-bar::before {
            @include center-vertically;
            background: contrast-color($nav-background);
            content: '';
            height: $nav-toggle-bar-height;
            transition: all .5s;
            width: 100%;
        }

        .nav-toggle-bar {
            margin-top: 0;
        }

        .nav-toggle-bar::after {
            margin-top: 2 * $nav-toggle-bar-height;
        }

        .nav-toggle-bar::before {
            margin-top: -2 * $nav-toggle-bar-height;
        }

        &.expanded .nav-toggle-bar {
            background: transparent;
        }

        &.expanded .nav-toggle-bar::after,
        &.expanded .nav-toggle-bar::before {
            background: contrast-color($nav-background);
            margin-top: 0;
        }

        &.expanded .nav-toggle-bar::after {
            @include transform(rotate(45deg));
        }

        &.expanded .nav-toggle-bar::before {
            @include transform(rotate(-45deg));
        }
    }

    /* nav */
    .nav {
        background: $nav-background;
        color: white;
        cursor: pointer;
        display: flex;
        flex-direction: column;
        font-size: 2rem;
        height: 100vh;
        left: -$nav-width;
        padding: 6rem 2rem 2rem 2rem;
        position: fixed;
        top: 0;
        transition: left .5s;
        width: $nav-width;
        z-index: $nav-z-index;

        &.expanded {
            left: 0;
        }

        ul {
            //@include center-vertically;
            list-style: none;
            margin: 0 0 auto;
            padding: 0;
        }
    }


    @media all and (max-width: 600px) {
        .nav {
            width: 100vw;
            left: -100vw;

        }
    }

</style>