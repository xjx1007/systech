//request.js
export default fetch = (url, params,method='GET') => {
    return new Promise((resolve, reject) => {
        Taro.request({
            url: globalData('host') + url,
            method: method,
            header: {
                'content-type': 'application/x-www-form-urlencoded',
            },
            data: params,
            success: (res) => {
                if (res.data.returnCode === 0) {
                    resolve(res.data.result)
                } else {
                    reject(res.data)
                }
            },
            fail:(err) => {
                reject(err)
            }
        })
    })
}

//api.js
import {fetch} from './request.js'
export const queryList = params =>{
  return fetch({
    url:'/xx/xx/xx',
    methods:'POST',
    params:params
  })
}

//page.js
import {queryList} from './api.js';
queryList({
  key1:value1,
  key2:value2
}).then(res=>{
  // success callback
  console.log(res)
}).catch(err=>{
  // fail callback
  console.log(err)
})