import React from 'react';
import DashboardPage from "../components/pages/DashboardPage";
import ProfilePage from "../components/pages/ProfilePage";
import TablesPage from "../components/pages/TablesPage";
import MapsPage from "../components/pages/MapsPage";
import Auth from '../components/pages/auth/auth';
import AdminList from '../components/pages/basic-information/admins/adminList';
import AgentList from '../components/pages/basic-information/agents/agentList';
import StationList from '../components/pages/basic-information/stations/stationList';
import DepoList from '../components/pages/basic-information/depos/depoList';
const routes = [
    {
        path: '/dashboard',
        name: 'dashboard',
        perName: 'پیشخوان',
        component: DashboardPage,
        exact: true,
        meta: {
            icon: 'fa-dashboard',
            parent: false,
        }
    },
    {
        path: '/actions',
        name: 'repairing actions',
        perName: 'عملیات های رفع حرابی',
        component: ProfilePage,
        exact: true,
        meta: {
            icon: 'fa-dashboard',
            parent: false
        }
    },
    {
        path: '/message-management',
        name: 'message management',
        perName: 'مدیریت پیام ها',
        component: TablesPage,
        exact: true,
        meta: {
            icon: 'fa-dashboard',
            parent: false
        }
    },
    {
        path: '/basic-information',
        name: 'basic information',
        perName: 'اطلاعات پایه',
        component: DashboardPage,
        meta: {
            icon: 'fa-dashboard',
            parent: true
        },
        child: [
            {
                path: '/basic-information/admins',
                name: 'admins',
                perName: 'ادمین ها',
                component: AdminList,
                meta: {
                    icon: 'fa-dashboard'
                }
            },
            {
                path: '/basic-information/agents',
                name: 'agents',
                perName: 'تعمیرکاران',
                component: AgentList,
                meta: {
                    icon: 'fa-dashboard'
                }
            },
            {
                path: '/basic-information/depos',
                name: 'depos',
                perName: 'depos',
                component: DepoList,
                meta: {
                    icon: 'fa-dashboard'
                }
            },
            {
                path: '/basic-information/stations',
                name: 'stations',
                perName: 'ایستگاهها',
                component: StationList,
                meta: {
                    icon: 'fa-dashboard'
                }
            }
        ]
    },
    {
        path: '/auth/userAuth',
        name: 'register',
        perName: 'ثبت نام',
        component: Auth,
        exact: true,
        meta: {
            icon: 'fa-lock',
            parent: false
        }
    }
];
export default routes;